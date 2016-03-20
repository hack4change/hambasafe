starterControllers.controller('ProfileCtrl', function ($scope, ProfileService) {
  ProfileService.get(1).then(function (response) {
    $scope.user = response.data;
  });

});
