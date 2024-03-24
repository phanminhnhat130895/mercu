import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { CandidateFilterModel } from "../models/output/get-candidate-filter.model";
import { UpdateCandidateRequest } from "../models/output/update-candidate.model";
import { CandidateRepsonse } from "../models/input/candidate.model";
import { CandidatesResponse } from "../models/input/candidates.model";
import { UpdateCandiadteStatusRepsonse } from "../models/input/update-candidate-status.model";
import { UpdateCandidatesStatusRequest } from "../models/output/update-candidates-status.model";

@Injectable()
export class CandidateService {
    constructor(private httpClient: HttpClient) {}

    private readonly apiPrefix = 'api/candidate'

    getCandidates(filter: CandidateFilterModel) {
        return this.httpClient.get<CandidatesResponse>(`${environment.apiUrl}/${this.apiPrefix}/candidates?SearchString=${filter.SearchName}&SearchDate=${filter.SearchDate}&InterviewerId=${filter.InterviewerId}`);
    }

    getCandidateById(id: string) {
        return this.httpClient.get<CandidateRepsonse>(`${environment.apiUrl}/${this.apiPrefix}/candidate/${id}`);
    }

    updateCandidate(data: UpdateCandidateRequest) {
        return this.httpClient.put<CandidateRepsonse>(`${environment.apiUrl}/${this.apiPrefix}/candidate`, data);
    }

    updateCandidatesStatus(data: UpdateCandidatesStatusRequest) {
        return this.httpClient.patch<UpdateCandiadteStatusRepsonse>(`${environment.apiUrl}/${this.apiPrefix}/candidates-status`, data);
    }
}