import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { InterviewerRepsonse } from "../models/input/interviewer.model";

@Injectable()
export class InterviewerService {
    constructor(private httpClient: HttpClient) {}

    private readonly apiPrefix = 'api/interviewer';

    getInterviewers() {
        return this.httpClient.get<InterviewerRepsonse>(`${environment.apiUrl}/${this.apiPrefix}/interviewers`);
    }
}