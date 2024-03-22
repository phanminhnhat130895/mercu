import { CandidateStatusEnum } from "../../common/enums/CandidateStatusEnum";
import { BaseModel } from "../base.model";
import { InterviewerModel } from "./interviewer.model";
import { JobModel } from "./job.model";

export class CandidateModel extends BaseModel {
    public Id!: string;
    public FirstName!: string;
    public LastName!: string;
    public PhoneNumber!: string;
    public Email!: string;
    public Status: CandidateStatusEnum;
    public Jobs: CandidateJobViewModel[]
}

export class CandidateJobViewModel {
    public Id!: string;
    public Job: JobModel;
    public Interviewer: InterviewerModel;
}