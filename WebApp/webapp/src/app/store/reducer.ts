import { ActionReducer, ActionReducerMap, MetaReducer, createReducer, on } from "@ngrx/store";
import { AppState, RootState, initialState } from "./state";
import * as actions from './actions';
import { localStorageSync, rehydrateApplicationState } from "ngrx-store-localstorage";

export const reducer = createReducer<AppState>(
    initialState,
    on(actions.getCandidates, (state) => {
        return { ...state, isLoading: true };
    }),
    on(actions.getCandidatesSuccess, (state, request) => {
        if (request.candidates && request.candidates.length > 0) {
            return { ...state, candidates: [...request.candidates], isLoading: false };
        }
        else {
            return { ...state, candidates: [], isLoading: false };
        }
    }),
    on(actions.getCandidatesError, (state) => {
        return { ...state, isLoading: false };
    }),
    on(actions.getInterviewers, (state) => {
        return { ...state, isLoadingInterviewers: true };
    }),
    on(actions.getInterviewersSuccess, (state, request) => {
        if (request.interviewers && request.interviewers.length > 0) {
            return { ...state, interviewers: [...request.interviewers], isLoadingInterviewers: false };
        }
        else {
            return { ...state, interviewers: [], isLoadingInterviewers: false };
        }
    }),
    on(actions.getInterviewersError, (state) => {
        return { ...state, isLoadingInterviewers: false };
    }),
    on(actions.updateCandidate, (state) => {
        return { ...state, isUpdating: true };
    }),
    on(actions.updateCandidateSuccess, (state, request) => {
        let updatedCandidate = state.candidates.find(x => x.id === request.candidate.id);
        if (updatedCandidate) {
            updatedCandidate = { ...updatedCandidate, 
                firstName: request.candidate.firstName, 
                lastName: request.candidate.lastName, 
                phoneNumber: request.candidate.phoneNumber,
                email: request.candidate.email };
            return { ...state, isUpdating: false, candidates: [...state.candidates.filter(x => x.id !== request.candidate.id), updatedCandidate] };
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
    on(actions.updateCandidatesStatus, (state) => {
        return { ...state, isUpdatingCandidateStatus: true };
    }),
    on(actions.updateCandidatesStatusSuccess, (state, request) => {
        const newCandidates = state.candidates.map(x => {
            const data = request.data.Data.find(d => d.id === x.id);
            if (data) {
                return { ...x, status: data.status };
            }
            return x;
        });
        return { ...state, isUpdatingCandidateStatus: false, candidates: [...newCandidates] };
    }),
    on(actions.updateCandidatesStatusError, (state) => {
        return { ...state, isUpdatingCandidateStatus: false };
    }),
    on(actions.selectCandidateToDrag, (state, request) => {
        return { ...state, dragCandidates: [...state.dragCandidates, request.candidate] };
    }),
    on(actions.removeCandidateToDrag, (state, request) => {
        return { ...state, dragCandidates: state.dragCandidates.filter(x => x.id !== request.id) };
    }),
    on(actions.setDragStatus, (state, request) => {
        return { ...state, dragCandidateStatus: request.status };
    })
)

export const reducers: ActionReducerMap<RootState> = {
    state: reducer
};

export function localStorageSyncReducer(reducer: ActionReducer<any>): ActionReducer<any> {
    return (state: AppState, action: any) => {
        const keys = ['state'];

        if  (action.type === actions.STORAGE && keys.includes(action.payload)) {
            const rehydratedState = rehydrateApplicationState([action.payload], localStorage, k => k, true);
            return { ...state, ...rehydratedState };
        }

        return localStorageSync({
            keys,
            rehydrate: true,
        })(reducer)(state, action);
    }
}

export const metaReducers: MetaReducer<RootState>[] = [localStorageSyncReducer];