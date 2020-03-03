(function () {
	'use strict';

	function dashboardController(environmentDashboardResources)
	{
		var vm = this;

		vm.model = {
			loading: false,
			dashboard: {
				currentEnvironment: '',
				groups: []
			}
		};

		function init()
		{
			vm.model.loading = true;

			//get data from api
			environmentDashboardResources.getEnvironmentDashboardInfo().then(function (response)
			{
				vm.model.loading = false;
				console.log(response);
				angular.copy(response, vm.model.dashboard);
			});
		}

		init();
	}

	angular.module('umbraco').controller('EnvironmentDashboardController', dashboardController);
})();