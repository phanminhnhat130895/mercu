import { CandidateStatusEnum } from "../common/enums/CandidateStatusEnum";
import { CandidateModel } from "../models/input/candidate.model";
import { CandidatesModel } from "../models/input/candidates.model";
import { InterviewerModel } from "../models/input/interviewer.model";

export interface AppState {
    candidates: CandidatesModel[];
    interviewers: InterviewerModel[];
    selectedCandidate: CandidateModel | undefined;
    isLoading: boolean;
    isLoadingInterviewers: boolean;
    isUpdating: boolean;
    isLoadingSelectedCandidate: boolean;
    dragCandidates: CandidatesModel[];
    isUpdatingCandidateStatus: boolean;
    dragCandidateStatus: CandidateStatusEnum;
}

export const initialState: AppState = {
    candidates: [],
    interviewers: [],
    selectedCandidate: undefined,
    isLoading: false,
    isLoadingInterviewers: false,
    isUpdating: false,
    isLoadingSelectedCandidate: false,
    dragCandidates: [],
    isUpdatingCandidateStatus: false,
    dragCandidateStatus: CandidateStatusEnum.Applied
}

export interface RootState {
    state: AppState
}