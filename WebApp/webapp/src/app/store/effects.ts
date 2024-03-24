import { Inject, Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { CandidateService } from "../services/candidate.service";
import { getCandidates, getCandidatesError, getCandidatesSuccess, getInterviewers, 
    getInterviewersError, getInterviewersSuccess, getSelectedCandidate, getSelectedCandidateError, 
    getSelectedCandidateSuccess, updateCandidate, updateCandidateError, updateCandidateSuccess, 
    updateCandidatesStatus, updateCandidatesStatusError, updateCandidatesStatusSuccess } from "./actions";
import { catchError, exhaustMap, map, of } from "rxjs";
import { InterviewerService } from "../services/interviewer.service";
import { TuiAlertService } from '@taiga-ui/core';

@Injectable()
export class StateEffects {
    constructor (
        private readonly actions$: Actions,
        private readonly candidateService: CandidateService,
        private readonly interviewerService: InterviewerService,
        @Inject(TuiAlertService) private readonly alerts: TuiAlertService
    ) {}

    loadCandidates$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(getCandidates),
            exhaustMap(data => this.candidateService.getCandidates(data.payload)
                .pipe(
                    map(response => getCandidatesSuccess({ candidates: response.candidates })),
                    catchError(() => {
                        this.alerts.open('Something went wrong!', { label: 'Error', status: 'error', hasIcon: false }).subscribe();
                        return of(getCandidatesError());
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
                    map(response => getInterviewersSuccess({ interviewers: response.interviewers })),
                    catchError(() => {
                        this.alerts.open('Something went wrong!', { label: 'Error', status: 'error', hasIcon: false }).subscribe();
                        return of(getInterviewersError());
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
                    map(response => getSelectedCandidateSuccess({ candidate: response.candidate })),
                    catchError(() => {
                        this.alerts.open('Something went wrong!', { label: 'Error', status: 'error', hasIcon: false }).subscribe();
                        return of(getSelectedCandidateError());
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
                    map(response => {
                        this.alerts.open('Update candidate successfully', { label: 'Success', status: 'success', hasIcon: false }).subscribe();
                        return updateCandidateSuccess({ candidate: response.candidate })
                    }),
                    catchError(() => {
                        this.alerts.open('Something went wrong!', { label: 'Error', status: 'error', hasIcon: false }).subscribe();
                        return of(updateCandidateError());
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
                    map(response => {
                        this.alerts.open('Update candidates status successfully', { label: 'Success', status: 'success', hasIcon: false }).subscribe();
                        return updateCandidatesStatusSuccess({ isSuccess: response.isSuccess, data: payload.data })
                    }),
                    catchError(() => {
                        this.alerts.open('Something went wrong!', { label: 'Error', status: 'error', hasIcon: false });
                        return of(updateCandidatesStatusError());
                    })
                )
            )
        )
    });
}