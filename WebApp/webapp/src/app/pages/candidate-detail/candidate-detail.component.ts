import { Component, OnDestroy, OnInit } from "@angular/core";
import { CandidateJobViewModel, CandidateModel } from "../../models/input/candidate.model";
import { ActivatedRoute } from '@angular/router';
import { TuiCountryIsoCode } from '@taiga-ui/i18n';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'app-candidate-detail',
    templateUrl: './candidate-detail.component.html'
})
export class CandidateDetailComponent implements OnInit, OnDestroy {
    constructor(private activatedRoute: ActivatedRoute) {}

    candidate: CandidateModel;
    countries = Object.values(TuiCountryIsoCode);
    countryIsoCode = TuiCountryIsoCode.AU;
    candidateForm: FormGroup;
    jobs: CandidateJobViewModel[] = [];
    columns: string[] = ['title', 'description', 'interviewer'];

    ngOnInit(): void {
        const id = this.activatedRoute.snapshot.queryParamMap.get('id');

        this.candidateForm = new FormGroup({
            firstName: new FormControl(this.candidate.FirstName, [Validators.required, Validators.maxLength(100)]),
            lastName: new FormControl(this.candidate.LastName, [Validators.required, Validators.maxLength(100)]),
            email: new FormControl(this.candidate.Email, [Validators.required, Validators.email, Validators.maxLength(255)]),
            phoneNumber: new FormControl(this.candidate.PhoneNumber, [Validators.required, Validators.maxLength(15)])
        });
    }

    saveCandidate() {
        if (this.candidateForm.valid) {

        }
    }

    ngOnDestroy(): void {
        throw new Error("Method not implemented.");
    }
}