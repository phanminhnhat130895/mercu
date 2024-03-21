import { CandidateModel } from "../models/input/candidate.model";
import { InterviewerModel } from "../models/input/interviewer.model";

export interface AppState {
    candidates: CandidateModel[];
    interviewers: InterviewerModel[];
    selectedCandidate: CandidateModel | undefined;
    isLoading: boolean;
    isLoadingInterviewers: boolean;
    isUpdating: boolean;
    isLoadingSelectedCandidate: boolean;
}

export const initialState: AppState = {
    candidates: [],
    interviewers: [],
    selectedCandidate: undefined,
    isLoading: false,
    isLoadingInterviewers: false,
    isUpdating: false,
    isLoadingSelectedCandidate: false
}