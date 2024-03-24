import { Action, createAction, props } from "@ngrx/store";
import { CandidateFilterModel } from "../models/output/get-candidate-filter.model";
import { CandidateModel } from "../models/input/candidate.model";
import { InterviewerModel } from "../models/input/interviewer.model";
import { UpdateCandidateRequest } from "../models/output/update-candidate.model";
import { CandidatesModel } from "../models/input/candidates.model";
import { CandidateStatusEnum } from "../common/enums/CandidateStatusEnum";
import { UpdateCandidatesStatusRequest } from "../models/output/update-candidates-status.model";

enum ActionTypes {
    GET_CANDIDATES = 'Get Candidates',
    GET_CANDIDATES_SUCCESS = 'Get Candidates Success',
    GET_CANDIDATES_ERROR = 'Get Candidates Error',
    GET_INTERVIEWERS = 'Get Interviewers',
    GET_INTERVIEWERS_SUCCESS = 'Get Interviewers Success',
    GET_INTERVIEWERS_ERROR = 'Get Interviewers Error',
    UPDATE_CANDIDATE = 'Update Candidate',
    UPDATE_CANDIDATE_SUCCESS = 'Update Candidate Success',
    UPDATE_CANDIDATE_ERROR = 'Update Candidate Error',
    GET_SELECTED_CANDIDATE = 'Get Selected Candidate',
    GET_SELECTED_CANDIDATE_SUCCESS = 'Get Selected Candidate Success',
    GET_SELECTED_CANDIDATE_ERROR = 'Get Selected Candidate Error',
    SELECT_CANDIDATE_TO_DRAG = 'Select Candidate To Drag',
    REMOVE_CANDIDATE_TO_DRAG = 'Remove Candidate To Drag',
    GET_DRAG_CANDIDATES = 'Get Drag Candidates',
    UPDATE_CANDIDATES_STATUS = 'Update Candidates Status',
    UPDATE_CANDIDATES_STATUS_SUCCESS = 'Update Candidates Status Success',
    UPDATE_CANDIDATES_STATUS_ERROR = 'Update Candidates Status Error',
    SET_DRAG_STATUS = 'Set Drag Status',
}

export const getCandidates = createAction(ActionTypes.GET_CANDIDATES, props<{ payload: CandidateFilterModel }>());

export const getCandidatesSuccess = createAction(ActionTypes.GET_CANDIDATES_SUCCESS, props<{ candidates: CandidatesModel[] }>());

export const getCandidatesError = createAction(ActionTypes.GET_CANDIDATES_ERROR);

export const getInterviewers = createAction(ActionTypes.GET_INTERVIEWERS);

export const getInterviewersSuccess = createAction(ActionTypes.GET_INTERVIEWERS_SUCCESS, props<{ interviewers: InterviewerModel[] }>());

export const getInterviewersError = createAction(ActionTypes.GET_INTERVIEWERS_ERROR);

export const updateCandidate = createAction(ActionTypes.UPDATE_CANDIDATE, props<{ payload: UpdateCandidateRequest }>());

export const updateCandidateSuccess = createAction(ActionTypes.UPDATE_CANDIDATE_SUCCESS, props<{ candidate: CandidateModel }>());

export const updateCandidateError = createAction(ActionTypes.UPDATE_CANDIDATE_ERROR);

export const getSelectedCandidate = createAction(ActionTypes.GET_SELECTED_CANDIDATE, props<{ id: string }>());

export const getSelectedCandidateSuccess = createAction(ActionTypes.GET_SELECTED_CANDIDATE_SUCCESS, props<{ candidate: CandidateModel }>());

export const getSelectedCandidateError = createAction(ActionTypes.GET_SELECTED_CANDIDATE_ERROR);

export const selectCandidateToDrag = createAction(ActionTypes.SELECT_CANDIDATE_TO_DRAG, props<{ candidate: CandidatesModel }>());

export const removeCandidateToDrag = createAction(ActionTypes.REMOVE_CANDIDATE_TO_DRAG, props<{ id: string }>());

export const getDragCandidate = createAction(ActionTypes.GET_DRAG_CANDIDATES);

export const updateCandidatesStatus = createAction(ActionTypes.UPDATE_CANDIDATES_STATUS, props<{ data: UpdateCandidatesStatusRequest }>());

export const updateCandidatesStatusSuccess = createAction(ActionTypes.UPDATE_CANDIDATES_STATUS_SUCCESS, props<{ isSuccess: boolean, data: UpdateCandidatesStatusRequest }>());

export const updateCandidatesStatusError = createAction(ActionTypes.UPDATE_CANDIDATES_STATUS_ERROR);

export const setDragStatus = createAction(ActionTypes.SET_DRAG_STATUS, props<{ status: CandidateStatusEnum }>());

export const STORAGE = '@ngrx/store/storage';

export class Storage implements Action {
    readonly type: string = STORAGE;
    constructor(readonly payload: string) {}
}