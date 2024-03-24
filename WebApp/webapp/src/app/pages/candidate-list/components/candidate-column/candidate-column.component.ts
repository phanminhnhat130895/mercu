import { Component, Input, OnDestroy, OnInit, Renderer2 } from "@angular/core";
import { CandidateStatusEnum } from "../../../../common/enums/CandidateStatusEnum";
import { CandidatesModel } from "../../../../models/input/candidates.model";
import { getCandidateStatusString } from "../../../../common/helper";
import { Store } from "@ngrx/store";
import { AppState } from "src/app/store/state";
import { SelectCandidates, SelectDragCandidates } from "src/app/store/selectors";
import { Subject, takeUntil } from "rxjs";
import { Storage, updateCandidatesStatus } from "src/app/store/actions";
import { UpdateCandidatesStatusRequest } from "src/app/models/output/update-candidates-status.model";

@Component({
    selector: 'app-candidate-column',
    templateUrl: './candidate-column.component.html'
})
export class CandidateColumnComponent implements OnInit, OnDestroy {
    constructor(private readonly store$: Store<AppState>,
        private readonly renderer: Renderer2) {}

    @Input() status!: CandidateStatusEnum;
    candidates: CandidatesModel[] = [];
    selectedCandidates: CandidatesModel[] = [];

    destroySubject$: Subject<boolean> = new Subject();

    ngOnInit(): void {
        this.renderer.listen('window', 'storage', event => {
            this.store$.dispatch(new Storage(event.key));
        });

        this.store$.select(SelectCandidates).pipe(
            takeUntil(this.destroySubject$)
        ).subscribe(data => {
            if (data) {
                this.candidates = data.filter(x => x.status === this.status);
                this.candidates = this.candidates.sort((a, b) => new Date(a.dateCreated).getTime() - new Date(b.dateCreated).getTime());
            }
        });

        this.store$.select(SelectDragCandidates).pipe(
            takeUntil(this.destroySubject$)
        ).subscribe(data => {
            if (data)
                this.selectedCandidates = data;
        });
    }

    ngOnDestroy(): void {
        this.destroySubject$.next(true);
        this.destroySubject$.complete();
    }

    StatusName(status: CandidateStatusEnum) {
        return getCandidateStatusString(status);
    }

    onDropCandidate() {
        if (this.selectedCandidates.length > 0 && this.selectedCandidates[0].status !== this.status) {
            const request = new UpdateCandidatesStatusRequest();
            request.Data = this.selectedCandidates.map(x => { return {...x, status: this.status} });
            this.store$.dispatch(updateCandidatesStatus({ data: request }));
        }
    }

    onDragOver(event: any) {
        event.preventDefault();
    }
}