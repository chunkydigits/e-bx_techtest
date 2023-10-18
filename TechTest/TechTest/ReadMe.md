Story:
	As an unauthorised user requesting GET /api/v1/{owner}/{repo}/contributors
	I want to see the authors of the last 100 commits in a GitHub repo of my choosing
	So that I can determine who has contributed to a GitHub repo

Acceptance criteria:
	Given a GitHub owner and repo
	When requesting GET /api/v1/{owner}/{repo}/contributors
	Then return the authors of the last 30 commits in the given repo

	Given a GitHub owner or repo that does not exist in Github
	When requesting GET /api/v1/{owner}/{repo}/contributors
	Then return HTTP 404 Not Found


Questions and Mitigation
========================
- Says in the description 100 but then the acceptance criteria that it's 30
	- I've catered for 30 as that's in the ACs
	- Could added an optional item to specify an amount that defaults to one of the specified numbers
- Testing
	- The BDD syntax lends to some cucumber tests (not done this in a while) but i thought it would be better spent doing the part that we were looking for i.e. the Mediatr and code structure
- For testing purposes I simply returned the whole object from the GitHub API since my repositories were fairly limitted in their contributions. 



A question I have after using this ... 
- Repositories 
	- do we need them if we are doing Mediation as we are almost doing the same thing with both patterns. 
	- The decoupling is done instead by Mediatr but I could see why we would use another layer, but seems unneccesary. 


