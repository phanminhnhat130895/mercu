import { CandidateStatusEnum } from "../../common/enums/CandidateStatusEnum";
import { BaseModel } from "../base.model";
import { InterviewerModel } from "./interviewer.model";
import { JobModel } from "./job.model";

export class CandidateRepsonse {
    public candidate!: CandidateModel;
}

export class CandidateModel extends BaseModel {
    public id!: string;
    public firstName!: string;
    public lastName!: string;
    public phoneNumber!: string;
    public email!: string;
    public status!: CandidateStatusEnum;
    public jobs!: CandidateJobViewModel[]
}

export class CandidateJobViewModel {
    public id!: string;
    public job!: JobModel;
    public interviewer!: InterviewerModel;
}