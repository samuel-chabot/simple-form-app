import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, map, of, take, tap, throwError } from 'rxjs';
import { ApplicationArea, Item } from '../interfaces';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  constructor(
    private http: HttpClient,
    private snackBar: MatSnackBar,
  ) {}

  public getItems(): Observable<Item[]> {
    return this.http.get<any>(`api/RequestForm`).pipe(
      catchError(() => {
        return throwError(() =>
          this.snackBar.open("Error occurred, check the network tab on your browser's developer tools for more details", 'Dismiss'),
        );
      }),
    );
  }

  public getItem(id: string): Observable<Item> {
    return this.http.get<any>(`api/RequestForm/${id}`).pipe(
      catchError(() => {
        return throwError(() =>
          this.snackBar.open("Error occurred, check the network tab on your browser's developer tools for more details", 'Dismiss'),
        );
      }),
    );
  }

  public createItem(item: Item): Observable<Item> {
    return this.http.post<any>(`api/RequestForm`, item).pipe(
      tap(() => this.snackBar.open('Item created successfully', 'Dismiss')),
      catchError(() => {
        return throwError(() =>
          this.snackBar.open("Error occurred, check the network tab on your browser's developer tools for more details", 'Dismiss'),
        );
      }),
    );
  }

  public editItem(item: Item): Observable<Item> {
    return this.http.put<any>(`api/RequestForm/${item.id}`, item).pipe(
      tap(() => this.snackBar.open('Item edited successfully', 'Dismiss')),
      catchError(() => {
        return throwError(() =>
          this.snackBar.open("Error occurred, check the network tab on your browser's developer tools for more details", 'Dismiss'),
        );
      }),
    );
  }

  public deleteItem(id: string): Observable<Item> {
    return this.http.delete<any>(`api/RequestForm/${id}`).pipe(
      tap(() => this.snackBar.open('Item deleted successfully', 'Dismiss')),
      catchError(() => {
        return throwError(() =>
          this.snackBar.open("Error occurred, check the network tab on your browser's developer tools for more details", 'Dismiss'),
        );
      }),
    );
  }
}
