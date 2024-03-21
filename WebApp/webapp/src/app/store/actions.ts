import { createAction, props } from "@ngrx/store";
import { CandidateFilterModel } from "../models/output/get-candidate-filter.model";
import { CandidateModel } from "../models/input/candidate.model";
import { InterviewerModel } from "../models/input/interviewer.model";
import { UpdateCandidateModel } from "../models/output/update-candidate.model";
import { CandidateJobStatusEnum } from "../common/enums/CandidateJobStatusEnum";

enum ActionTypes {
    GET_CANDIDATES = 'Get Candidates',
    GET_CANDIDATES_SUCCESS = 'Get Candidates Success',
    GET_CANDIDATES_ERROR = 'Get Candidates Error',
    GET_INTERVIEWERS = 'Get Interviewers',
    GET_INTERVIEWERS_SUCCESS = 'Get Interviewers Success',
    GET_INTERVIEWERS_ERROR = 'Get Interviewers Error',
    GET_ISLOADING = 'Get IsLoading',
    GET_ISUPDATING = 'Get IsUpdating',
    UPDATE_CANDIDATE = 'Update Candidate',
    UPDATE_CANDIDATE_SUCCESS = 'Update Candidate Success',
    UPDATE_CANDIDATE_ERROR = 'Update Candidate Error',
    GET_SELECTED_CANDIDATE = 'Get Selected Candidate',
    GET_SELECTED_CANDIDATE_SUCCESS = 'Get Selected Candidate Success',
    GET_SELECTED_CANDIDATE_ERROR = 'Get Selected Candidate Error',
    UPDATE_CANDIDATE_JOB_STATUS = 'Update Candidate Job Status',
    UPDATE_CANDIDATE_JOB_STATUS_SUCCESS = 'Update Candidate Job Status Success',
    UPDATE_CANDIDATE_JOB_STATUS_ERROR = 'Update Candidate Job Status Error',
}

export const getCandidates = createAction(ActionTypes.GET_CANDIDATES, props<{ payload: CandidateFilterModel }>());

export const getCandidatesSuccess = createAction(ActionTypes.GET_CANDIDATES_SUCCESS, props<{ candidates: CandidateModel[] }>());

export const getCandidatesError = createAction(ActionTypes.GET_CANDIDATES_ERROR);

export const getInterviewers = createAction(ActionTypes.GET_INTERVIEWERS);

export const getInterviewersSuccess = createAction(ActionTypes.GET_INTERVIEWERS_SUCCESS, props<{ interviewers: InterviewerModel[] }>());

export const getInterviewersError = createAction(ActionTypes.GET_INTERVIEWERS_ERROR);

export const getIsLoading = createAction(ActionTypes.GET_ISLOADING);

export const getIsUpdating = createAction(ActionTypes.GET_ISUPDATING);

export const updateCandidate = createAction(ActionTypes.UPDATE_CANDIDATE, props<{ payload: UpdateCandidateModel }>());

export const updateCandidateSuccess = createAction(ActionTypes.UPDATE_CANDIDATE_SUCCESS, props<{ candidate: CandidateModel }>());

export const updateCandidateError = createAction(ActionTypes.UPDATE_CANDIDATE_ERROR);

export const getSelectedCandidate = createAction(ActionTypes.GET_SELECTED_CANDIDATE, props<{ id: string }>());

export const getSelectedCandidateSuccess = createAction(ActionTypes.GET_SELECTED_CANDIDATE_SUCCESS, props<{ candidate: CandidateModel }>());

export const getSelectedCandidateError = createAction(ActionTypes.GET_SELECTED_CANDIDATE_ERROR);

export const updateCandidateJobStatus = createAction(ActionTypes.UPDATE_CANDIDATE_JOB_STATUS, props<{ payload: { id: string, status: CandidateJobStatusEnum } }>());

export const updateCandidateJobStatusSuccess = createAction(ActionTypes.UPDATE_CANDIDATE_JOB_STATUS_SUCCESS, props<{ isSuccess: boolean }>());

export const updateCandidateJobStatusError = createAction(ActionTypes.UPDATE_CANDIDATE_JOB_STATUS_ERROR);