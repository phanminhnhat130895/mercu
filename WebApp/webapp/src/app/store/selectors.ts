import { CandidateModel } from "../models/input/candidate.model";
import { CandidatesModel } from "../models/input/candidates.model";
import { InterviewerModel } from "../models/input/interviewer.model";
import { AppState } from "./state";
import { createSelector } from '@ngrx/store';

const getIsLoading = (state: AppState): boolean => state.isLoading || 
                                                   state.isUpdating || 
                                                   state.isLoadingInterviewers || 
                                                   state.isLoadingSelectedCandidate || 
                                                   state.isUpdatingCandidateStatus;

const getCandidates = (state: AppState): CandidatesModel[] => state.candidates;

const getInterviewer = (state: AppState): InterviewerModel[] => state.interviewers;

const getSelectedCandidate = (state: AppState): CandidateModel | undefined => state.selectedCandidate;

const getDragCandidates = (state: AppState): CandidatesModel[] => state.dragCandidates?.filter(x => x.status === state.dragCandidateStatus);

const SelectState = (state: any) => state.state;

export const SelectIsLoading = createSelector(SelectState, getIsLoading);

export const SelectCandidates = createSelector(SelectState, getCandidates);

export const SelectInterviewers = createSelector(SelectState, getInterviewer);

export const SelectSelectedCandidate = createSelector(SelectState, getSelectedCandidate);

export const SelectDragCandidates = createSelector(SelectState, getDragCandidates);