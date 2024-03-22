import { CandidateStatusEnum } from "./enums/CandidateStatusEnum";

export function handleHttpError(error: any) {
    if (error.error.statusCode == 400) {
        if (error.error.message.includes(",")) {
            let messages = error.error.message.split(',');
            for (let message of messages) {
                console.log(message);
            }
        } else {
            console.log(error.message);
        }
    } else {
        console.log(error.message);
    }
}

export function getCandidateStatusString(value: CandidateStatusEnum) {
    switch(value) {
        case CandidateStatusEnum.Applied:
            return 'Applied';
        case CandidateStatusEnum.Hired:
            return 'Hired';
        case CandidateStatusEnum.Interviewing:
            return 'Interviewing';
        case CandidateStatusEnum.Offered:
            return 'Offered';
    }
}