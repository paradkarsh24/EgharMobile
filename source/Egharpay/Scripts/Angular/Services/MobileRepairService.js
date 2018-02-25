﻿(function () {
    'use strict';

    angular
        .module('Egharpay')
        .factory('MobileRepairService', MobileRepairService);

    MobileRepairService.$inject = ['$http'];

    function MobileRepairService($http) {
        var service = {
            createMobileRepairRequest: createMobileRepairRequest,
            retrieveMobileRepairOrders: retrieveMobileRepairOrders,
            retrieveMobileRepairOrdersByMobile: retrieveMobileRepairOrdersByMobile,
            mobileRepairState: mobileRepairState
        };

        return service;

        function createMobileRepairRequest(model) {
            var url = "/MobileRepair/Create",
                data = {
                    model: model
                };
            return $http.post(url, data);
        }

        function retrieveMobileRepairOrdersByMobile(mobileNumber) {
            var url = "/MobileRepair/RetrieveMobileRepairOrders/" + mobileNumber;
            return $http.get(url, data);
        }

        function retrieveMobileRepairOrders(Paging, OrderBy) {
            var url = "/MobileRepair/List",
            data = {
                paging: Paging,
                orderBy: new Array(OrderBy)
            };
            return $http.get(url, data);
        }

        function mobileRepairState(mobileRepairId, mobileRepairStateId) {
            var url = "/MobileRepair/UpdateMobileRepairState",
            data = {
                mobileRepairId: mobileRepairId,
                mobileRepairStateId: mobileRepairStateId
            };
            return $http.post(url, data);
        }

    }
})();