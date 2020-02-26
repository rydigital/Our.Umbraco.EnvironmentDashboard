(function () {
	'use strict';

	function environmentDashboardResources($http, umbRequestHelper) {

		function getEnvironmentDashboardInfo() {
			return umbRequestHelper.resourcePromise(
				$http.get('/umbraco/backoffice/api/environmentdashboard/dashboardinfo'),
				'Failed to retrieve environment dashboard info'
			);
		}

		return {
			getEnvironmentDashboardInfo: getEnvironmentDashboardInfo
		};
	}

	angular.module('umbraco.resources').factory('environmentDashboardResources', environmentDashboardResources);
})();