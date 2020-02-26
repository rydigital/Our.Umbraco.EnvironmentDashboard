(function () {
	'use strict';

	function dashboardController(environmentDashboardResources)
	{
		var vm = this;

		vm.dashboard = {
			loading: false,
			info: {
				currentEnvironment: '',
				databaseServer: '',
				databaseName: '',
				cloudStorageUrl: '',
				cloudStorageAccountName: ''
			}
		};

		function init()
		{
			vm.dashboard.loading = true;

			//get data from api
			environmentDashboardResources.getEnvironmentDashboardInfo().then(function (response)
			{
				vm.dashboard.loading = false;
				angular.copy(response, vm.dashboard.info);
			});
		}

		init();
	}

	angular.module('umbraco').controller('EnvironmentDashboardController', dashboardController);
})();