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