import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'truncate' })
export class TruncatePipe implements PipeTransform {
    transform(value: string, length: number) {
        if (value.length > length)
            return value.split(' ').slice(0, length).join(' ') + '...';
        return value;
    }
}
