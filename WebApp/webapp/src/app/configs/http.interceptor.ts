import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError, retry } from 'rxjs/operators';

@Injectable()
export class ConfigInterceptor implements HttpInterceptor {
  constructor() {}

  intercept(request: HttpRequest<any>, next: HttpHandler) : Observable<HttpEvent<any>> {
    request = request.clone({
      setHeaders: {
        'Content-Type': 'application/json',
      }
    })

    return next.handle(request).pipe(
      retry(1),
      map((event: HttpEvent<any>) => {
        return event;
      }),
      catchError((error: HttpErrorResponse) => {
        return throwError(() => error);
      })
    )
  }
}