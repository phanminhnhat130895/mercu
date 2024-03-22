import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { CandidateService } from "../services/candidate.service";
import { getCandidates, getCandidatesError, getCandidatesSuccess, getInterviewers, 
    getInterviewersError, getInterviewersSuccess, getSelectedCandidate, getSelectedCandidateError, 
    getSelectedCandidateSuccess, updateCandidate, updateCandidateError, updateCandidateSuccess, 
    updateCandidatesStatus, updateCandidatesStatusError, updateCandidatesStatusSuccess } from "./actions";
import { catchError, exhaustMap, map } from "rxjs";
import { InterviewerService } from "../services/interviewer.service";
import { TuiAlertService } from '@taiga-ui/core';

@Injectable()
export class StateEffects {
    constructor (
        private readonly actions$: Actions,
        private readonly candidateService: CandidateService,
        private readonly interviewerService: InterviewerService,
        private readonly alerts: TuiAlertService
    ) {}

    loadCandidates$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(getCandidates),
            exhaustMap(data => this.candidateService.getCandidates(data.payload)
                .pipe(
                    map(response => getCandidatesSuccess({ candidates: response })),
                    catchError(async () => {
                        this.alerts.open('Something went wrong!', { label: 'Error', status: 'error', hasIcon: false });
                        return getCandidatesError();
                    })
                )
            )
        )
    });

    loadInterviewers$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(getInterviewers),
            exhaustMap(_ => this.interviewerService.getInterviewers()
                .pipe(
                    map(response => getInterviewersSuccess({ interviewers: response })),
                    catchError(async () => {
                        this.alerts.open('Something went wrong!', { label: 'Error', status: 'error', hasIcon: false });
                        return getInterviewersError();
                    })
                )
            )
        )
    });

    loadSelectedCandidate$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(getSelectedCandidate),
            exhaustMap(data => this.candidateService.getCandidateById(data.id)
                .pipe(
                    map(response => getSelectedCandidateSuccess({ candidate: response })),
                    catchError(async () => {
                        this.alerts.open('Something went wrong!', { label: 'Error', status: 'error', hasIcon: false });
                        return getSelectedCandidateError();
                    })
                )
            )
        )
    });

    updateCandidate$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(updateCandidate),
            exhaustMap(data => this.candidateService.updateCandidate(data.payload)
                .pipe(
                    map(response => updateCandidateSuccess({ candidate: response })),
                    catchError(async () => {
                        this.alerts.open('Something went wrong!', { label: 'Error', status: 'error', hasIcon: false });
                        return updateCandidateError();
                    })
                )
            )
        )
    });

    updateCandidatesStatus$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(updateCandidatesStatus),
            exhaustMap(payload => this.candidateService.updateCandidatesStatus(payload.data)
                .pipe(
                    map(response => updateCandidatesStatusSuccess({ isSuccess: response })),
                    catchError(async () => {
                        this.alerts.open('Something went wrong!', { label: 'Error', status: 'error', hasIcon: false });
                        return updateCandidatesStatusError();
                    })
                )
            )
        )
    });
}