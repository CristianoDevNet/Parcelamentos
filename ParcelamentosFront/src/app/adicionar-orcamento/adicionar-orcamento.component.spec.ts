import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdicionarOrcamentoComponent } from './adicionar-orcamento.component';

describe('AdicionarOrcamentoComponent', () => {
  let component: AdicionarOrcamentoComponent;
  let fixture: ComponentFixture<AdicionarOrcamentoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdicionarOrcamentoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdicionarOrcamentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
