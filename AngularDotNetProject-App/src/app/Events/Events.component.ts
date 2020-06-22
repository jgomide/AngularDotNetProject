import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-events',
  templateUrl: './Events.component.html',
  styleUrls: ['./Events.component.css']
})
export class EventsComponent implements OnInit {

  events: any;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getEvents();
  }

  getEvents(){
    this.http.get('https://localhost:5001/api/values').subscribe(response => {
        this.events = response;
        console.log(response);
    }, error => {
        console.log(error);
    });
  }
}
