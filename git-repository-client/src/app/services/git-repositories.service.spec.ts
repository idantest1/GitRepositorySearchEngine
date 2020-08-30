import { TestBed } from '@angular/core/testing';

import { GitRepositoriesService } from './git-repositories.service';

describe('GitRepositoriesService', () => {
  let service: GitRepositoriesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GitRepositoriesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
