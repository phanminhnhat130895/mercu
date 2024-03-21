import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { CandidateFilterModel } from "../models/output/get-candidate-filter.model";
import { environment } from "src/environments/environment";
import { UpdateCandidateModel } from "../models/output/update-candidate.model";
import { CandidateJobStatusEnum } from "../common/enums/CandidateJobStatusEnum";
import { CandidateModel } from "../models/input/candidate.model";

@Injectable()
export class CandidateService {
    constructor(private httpClient: HttpClient) {}

    private readonly apiPrefix = 'api/candidate'

    getCandidates(filter: CandidateFilterModel) {
        return this.httpClient.get<CandidateModel[]>(`${environment.apiUrl}/${this.apiPrefix}/candidates?SearchString=${filter.SearchName}&SearchDate=${filter.SearchDate}&InterviewerId=${filter.InterviewerId}`);
    }

    getCandidateById(id: string) {
        return this.httpClient.get<CandidateModel>(`${environment.apiUrl}/${this.apiPrefix}/candidate?id=${id}`);
    }

    updateCandidate(data: UpdateCandidateModel) {
        return this.httpClient.put<CandidateModel>(`${environment.apiUrl}/${this.apiPrefix}/candidate`, data);
    }

    updateCandidateJobStatus(id: string, status: CandidateJobStatusEnum) {
        return this.httpClient.patch<boolean>(`${environment.apiUrl}/${this.apiPrefix}/candidate-job-status?id=${id}&status=${status}`, null);
    }
}