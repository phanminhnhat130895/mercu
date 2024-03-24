import { Component, OnDestroy, OnInit } from "@angular/core";
import { CandidateJobViewModel, CandidateModel } from "../../models/input/candidate.model";
import { ActivatedRoute } from '@angular/router';
import { TuiCountryIsoCode } from '@taiga-ui/i18n';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Store } from "@ngrx/store";
import { AppState } from "src/app/store/state";
import { getSelectedCandidate, updateCandidate } from "src/app/store/actions";
import { SelectSelectedCandidate } from "src/app/store/selectors";
import { Subject, takeUntil } from "rxjs";
import { UpdateCandidateModel, UpdateCandidateRequest } from "src/app/models/output/update-candidate.model";

@Component({
    selector: 'app-candidate-detail',
    templateUrl: './candidate-detail.component.html'
})
export class CandidateDetailComponent implements OnInit, OnDestroy {
    constructor(private readonly activatedRoute: ActivatedRoute,
        private readonly store$: Store<AppState>) {}

    candidate: CandidateModel | undefined;
    countries = Object.values(TuiCountryIsoCode);
    countryIsoCode = TuiCountryIsoCode.AU;
    candidateForm!: FormGroup;
    jobs: CandidateJobViewModel[] = [];
    readonly columns: string[] = ['title', 'description', 'interviewer'];

    destroySubject$: Subject<boolean> = new Subject();

    ngOnInit(): void {
        const id = this.activatedRoute.snapshot.params['id'];
        if (id)
            this.store$.dispatch(getSelectedCandidate({ id: id }));

        this.store$.select(SelectSelectedCandidate).pipe(
            takeUntil(this.destroySubject$)
        ).subscribe(data => {
            if (data) {
                this.candidate = data;
                this.jobs = this.candidate.jobs;
                this.candidateForm = new FormGroup({
                    firstName: new FormControl(this.candidate?.firstName, [Validators.required, Validators.maxLength(100)]),
                    lastName: new FormControl(this.candidate?.lastName, [Validators.required, Validators.maxLength(100)]),
                    email: new FormControl(this.candidate?.email, [Validators.required, Validators.email, Validators.maxLength(255)]),
                    phoneNumber: new FormControl(this.candidate?.phoneNumber, [Validators.required, Validators.maxLength(15)])
                });
            }
        });
    }

    saveCandidate() {
        if (this.candidateForm?.valid && this.candidate) {
            const candidateData = new UpdateCandidateModel();
            candidateData.Id = this.candidate.id;
            candidateData.FirstName = this.candidateForm.get('firstName')?.value;
            candidateData.LastName = this.candidateForm.get('lastName')?.value;
            candidateData.PhoneNumber = this.candidateForm.get('phoneNumber')?.value;
            candidateData.Email = this.candidateForm.get('email')?.value;
            const request = new UpdateCandidateRequest();
            request.Candidate = candidateData;
            this.store$.dispatch(updateCandidate({ payload: request }));
        }
    }

    ngOnDestroy(): void {
        this.destroySubject$.next(true);
        this.destroySubject$.complete();
    }
}