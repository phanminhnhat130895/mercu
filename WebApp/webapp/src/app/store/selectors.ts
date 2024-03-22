import { CandidateModel } from "../models/input/candidate.model";
import { CandidatesModel } from "../models/input/candidates.model";
import { InterviewerModel } from "../models/input/interviewer.model";
import { StateNames } from "./names";
import { AppState } from "./state";
import { MemoizedSelector, createFeatureSelector, createSelector } from '@ngrx/store';

const getIsLoading = (state: AppState): boolean => state.isLoading;

const getIsUpdating = (state: AppState): boolean => state.isUpdating;

const getCandidates = (state: AppState): CandidatesModel[] => state.candidates;

const getInterviewer = (state: AppState): InterviewerModel[] => state.interviewers;

const getSelectedCandidate = (state: AppState): CandidateModel | undefined => state.selectedCandidate;

const getIsLoadingInterviewers = (state: AppState): boolean => state.isLoadingInterviewers;

const getIsLoadingSelectedCandidate = (state: AppState): boolean => state.isLoadingSelectedCandidate;

const getIsUpdaingCandidatesStatus = (state: AppState): boolean => state.isUpdatingCandidateStatus;

const getDragCandidates = (state: AppState): CandidatesModel[] => state.dragCandidates;

export const SelectState: MemoizedSelector<object, AppState> = createFeatureSelector<AppState>(StateNames.NAME);

export const SelectIsLoading: MemoizedSelector<object, boolean> = createSelector(SelectState, getIsLoading);

export const SelectIsUpdating: MemoizedSelector<object, boolean> = createSelector(SelectState, getIsUpdating);

export const SelectCandidates: MemoizedSelector<object, CandidatesModel[]> = createSelector(SelectState, getCandidates);

export const SelectInterviewer: MemoizedSelector<object, InterviewerModel[]> = createSelector(SelectState, getInterviewer);

export const SelectSelectedCandidate: MemoizedSelector<object, CandidateModel | undefined> = createSelector(SelectState, getSelectedCandidate);

export const SelectIsLoadingInterviewers: MemoizedSelector<object, boolean> = createSelector(SelectState, getIsLoadingInterviewers);

export const SelectIsLoadingSelectedCandidate: MemoizedSelector<object, boolean> = createSelector(SelectState, getIsLoadingSelectedCandidate);

export const SelectIsUpdatingCandidateStatus: MemoizedSelector<object, boolean> = createSelector(SelectState, getIsUpdaingCandidatesStatus);

export const SelectDragCandidates: MemoizedSelector<object, CandidatesModel[]> = createSelector(SelectState, getDragCandidates);