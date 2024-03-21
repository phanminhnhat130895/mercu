import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { CandidateService } from "../services/candidate.service";
import { getCandidates, getCandidatesError, getCandidatesSuccess, getInterviewers, getInterviewersError, getInterviewersSuccess, getSelectedCandidate, getSelectedCandidateError, getSelectedCandidateSuccess, updateCandidate, updateCandidateError, updateCandidateJobStatus, updateCandidateJobStatusError, updateCandidateJobStatusSuccess, updateCandidateSuccess } from "./actions";
import { catchError, exhaustMap, map } from "rxjs";
import { InterviewerService } from "../services/interviewer.service";

@Injectable()
export class StateEffects {
    constructor (
        private readonly actions$: Actions,
        private readonly candidateService: CandidateService,
        private readonly interviewerService: InterviewerService
    ) {}

    loadCandidates$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(getCandidates),
            exhaustMap(data => this.candidateService.getCandidates(data.payload)
                .pipe(
                    map(response => getCandidatesSuccess({ candidates: response })),
                    catchError(async () => getCandidatesError())
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
                    catchError(async () => getInterviewersError())
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
                    catchError(async () => getSelectedCandidateError())
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
                    catchError(async () => updateCandidateError())
                )
            )
        )
    });

    updateCandidateJobStatus$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(updateCandidateJobStatus),
            exhaustMap(data => this.candidateService.updateCandidateJobStatus(data.payload.id, data.payload.status)
                .pipe(
                    map(resposne => updateCandidateJobStatusSuccess({ isSuccess: resposne })),
                    catchError(async () => updateCandidateJobStatusError())
                )
            )
        )
    });
}