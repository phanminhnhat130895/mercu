import { Component, Input, OnDestroy, OnInit } from "@angular/core";
import { Router } from '@angular/router';
import { CandidatesModel } from "../../../../models/input/candidates.model";
import { Store } from "@ngrx/store";
import { AppState } from "src/app/store/state";
import { removeCandidateToDrag, selectCandidateToDrag, setDragStatus } from "src/app/store/actions";
import { FormControl, FormGroup } from "@angular/forms";
import { Subject, takeUntil } from "rxjs";

@Component({
    selector: 'app-candidate-card',
    templateUrl: './candidate-card.component.html',
    styleUrls: ['./candidate-card.component.scss']
})
export class CandidateCardComponent implements OnInit, OnDestroy {
    constructor(private readonly router: Router,
        private readonly store$: Store<AppState>) {}

    @Input() candidate!: CandidatesModel;
    cardForm!: FormGroup;
    destroySubject$: Subject<boolean> = new Subject();

    ngOnInit(): void {
        this.cardForm = new FormGroup({
            cardCheckBox: new FormControl(false)
        });

        this.cardForm.get('cardCheckBox')?.valueChanges.pipe(
            takeUntil(this.destroySubject$)
        ).subscribe(value => {
            if (value) {
                this.store$.dispatch(selectCandidateToDrag({ candidate: this.candidate }));
            }
            else {
                this.store$.dispatch(removeCandidateToDrag({ id: this.candidate.id }));
            }
        })
    }

    ngOnDestroy(): void {
        this.destroySubject$.next(true);
        this.destroySubject$.complete();
    }

    goToCandidateDetail() {
        const url = this.router.serializeUrl(this.router.createUrlTree([`/candidate-detail/${this.candidate.id}`]));
        window.open(url, '_blank');
    }

    onDragCandidate() {
        this.store$.dispatch(setDragStatus({ status: this.candidate.status }));
    }
}