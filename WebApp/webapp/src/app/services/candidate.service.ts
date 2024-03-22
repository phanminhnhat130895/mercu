import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { CandidateFilterModel } from "../models/output/get-candidate-filter.model";
import { UpdateCandidateModel } from "../models/output/update-candidate.model";
import { CandidateModel } from "../models/input/candidate.model";
import { CandidatesModel } from "../models/input/candidates.model";
import { UpdateCandidatesStatus } from "../models/output/update-candidates-status.model";

@Injectable()
export class CandidateService {
    constructor(private httpClient: HttpClient) {}

    private readonly apiPrefix = 'api/candidate'

    getCandidates(filter: CandidateFilterModel) {
        return this.httpClient.get<CandidatesModel[]>(`${environment.apiUrl}/${this.apiPrefix}/candidates?SearchString=${filter.SearchName}&SearchDate=${filter.SearchDate}&InterviewerId=${filter.InterviewerId}`);
    }

    getCandidateById(id: string) {
        return this.httpClient.get<CandidateModel>(`${environment.apiUrl}/${this.apiPrefix}/candidate?id=${id}`);
    }

    updateCandidate(data: UpdateCandidateModel) {
        return this.httpClient.put<CandidateModel>(`${environment.apiUrl}/${this.apiPrefix}/candidate`, data);
    }

    updateCandidatesStatus(data: UpdateCandidatesStatus[]) {
        return this.httpClient.patch<boolean>(`${environment.apiUrl}/${this.apiPrefix}/candidates-status`, data);
    }
}