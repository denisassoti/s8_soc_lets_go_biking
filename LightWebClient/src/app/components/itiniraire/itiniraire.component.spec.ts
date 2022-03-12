import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItiniraireComponent } from './itiniraire.component';

describe('ItiniraireComponent', () => {
  let component: ItiniraireComponent;
  let fixture: ComponentFixture<ItiniraireComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItiniraireComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItiniraireComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
