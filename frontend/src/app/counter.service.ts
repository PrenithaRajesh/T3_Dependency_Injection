import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { CounterResponse } from "./counter.model";

@Injectable({providedIn: 'root'})
export class CounterService {
    constructor(private http: HttpClient) {}

    getCount() {
        console.log('getall called');
        return this.http.get<CounterResponse>('http://localhost:5000/api/Counter/getall');
    }

    increment() {
        console.log('incrementall called');
        return this.http.post('http://localhost:5000/api/Counter/incrementall', null);
    }

}