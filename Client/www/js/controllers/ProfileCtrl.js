starterControllers.controller('ProfileCtrl', function ($scope, ProfileService) {
  ProfileService.get(1);

});
