import { Component, OnInit } from '@angular/core';
import { CounterService } from '../counter.service';
import { CounterResponse } from '../counter.model';

@Component({
  selector: 'app-counter',
  templateUrl: './counter.component.html',
  styleUrls: ['./counter.component.css']
})
export class CounterComponent implements OnInit {

  scopedAll : number[] = [];
  transientAll : number[] = [];
  singletonAll : number[] = [];

  response : CounterResponse = {
    scoped: 1,
    transient: 1,
    singleton: 1
  };

  constructor(private counterService : CounterService) { }

  ngOnInit(): void {
    this.counterService.getCount().subscribe(response => {
      console.log(response);
      this.response = response;
      this.scopedAll.push(response.scoped);
      this.transientAll.push(response.transient);
      this.singletonAll.push(response.singleton);
    });
  }

  increment() {
    this.counterService.increment().subscribe(() => {
      this.counterService.getCount().subscribe(response => {
        console.log(response);
        this.response = response;
        this.scopedAll.push(response.scoped);
        this.transientAll.push(response.transient);
        this.singletonAll.push(response.singleton);
      });
    });
  }

}
