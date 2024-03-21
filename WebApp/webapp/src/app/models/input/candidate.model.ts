import { CandidateJobStatusEnum } from "src/app/common/enums/CandidateJobStatusEnum";
import { BaseModel } from "../base.model";

export class CandidateModel extends BaseModel {
    public Id!: string;
    public FirstName!: string;
    public LastName!: string;
    public PhoneNumber!: string;
    public Email!: string;
}

export class CandidateJobViewModel {
    public Id!: string;
    public JobId!: string;
    public InterviewerId!: string;
    public Status!: CandidateJobStatusEnum;
}