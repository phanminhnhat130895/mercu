import { createReducer, on } from "@ngrx/store";
import { AppState, initialState } from "./state";
import * as actions from './actions';

export const reducer = createReducer<AppState>(
    initialState,
    on(actions.getCandidates, (state) => {
        return { ...state, isLoading: true };
    }),
    on(actions.getCandidatesSuccess, (state, request) => {
        return { ...state, candidates: request.candidates, isLoading: false };
    }),
    on(actions.getCandidatesError, (state) => {
        return { ...state, isLoading: false };
    }),
    on(actions.getInterviewers, (state) => {
        return { ...state, isLoadingInterviewers: true };
    }),
    on(actions.getInterviewersSuccess, (state, request) => {
        return { ...state, interviewers: request.interviewers, isLoadingInterviewers: false };
    }),
    on(actions.getInterviewersError, (state) => {
        return { ...state, isLoadingInterviewers: false };
    }),
    on(actions.updateCandidate, (state) => {
        return { ...state, isUpdating: true };
    }),
    on(actions.updateCandidateSuccess, (state, request) => {
        const updatedCandidate = state.candidates.find(x => x.Id === request.candidate.Id);
        if (updatedCandidate) {
            updatedCandidate.FirstName = request.candidate.FirstName;
            updatedCandidate.LastName = request.candidate.LastName;
            updatedCandidate.PhoneNumber = request.candidate.PhoneNumber;
            updatedCandidate.Email = request.candidate.Email;
            return { ...state, isUpdating: false, candidates: [...state.candidates.filter(x => x.Id !== request.candidate.Id), updatedCandidate] };
        }
        return { ...state, isUpdating: false };
    }),
    on(actions.updateCandidateError, (state) => {
        return { ...state, isUpdating: false };
    }),
    on(actions.getSelectedCandidate, (state) => {
        return { ...state, isLoadingSelectedCandidate: true };
    }),
    on(actions.getSelectedCandidateSuccess, (state, request) => {
        return { ...state, isLoadingSelectedCandidate: false, selectedCandidate: request.candidate };
    }),
    on(actions.getSelectedCandidateError, (state) => {
        return { ...state, isLoadingSelectedCandidate: false };
    }),
)