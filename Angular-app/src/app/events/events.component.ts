import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventService } from '../_services/Event.service';
import { Event } from '../_models/Event';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';


@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})

export class EventsComponent implements OnInit {

  
  filteredEvents: Event[];
  events: Event[];
  
  modalRef: BsModalRef;  

  imageWidth = 50;
  imageMargin = 2;
  imageOnOff = true;  

  _filterList: string = '';  
 
  get filterList(): string{
    return this._filterList;
  }
  set filterList(value: string){
    this._filterList = value;
    this.filteredEvents = this.filterList ? this.filterEvents(this.filterList) : this.events;
  }    

  constructor(
    private eventService: EventService,
    private modalService: BsModalService    
    ) {}

  openModal(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template);
  }

  ngOnInit() {
    this.getEvents();
  }

  filterEvents(filterBy: string): Event[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.events.filter(
      event => event.name.toLocaleLowerCase().indexOf(filterBy) !== -1
      
    );
  }

  showImage(){
    this.imageOnOff = !this.imageOnOff;    
  }

  getEvents(){
    this.eventService.getEventAll().subscribe(
      (_events: Event[]) => {
      this.events = _events;
      this.filteredEvents = this.events;      
      console.log(_events);
    }, error => {
      console.log(error);
    });
  }
}
