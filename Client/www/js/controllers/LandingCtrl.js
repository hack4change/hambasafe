starterControllers.controller('LandingCtrl', function ($scope, $stateParams, Facebook, ProfileService, $location) {
  $scope.getLoginStatus = function () {
    Facebook.logout();
    Facebook.getLoginStatus(function (response) {
      console.log(response);
      if (response.status === 'connected') {

        $location.path('app/home');
      } else {
        $scope.loggedIn = false;
      }
    });
  };

  $scope.fbLogin = function () {
    Facebook
    Facebook.login(function (response) {
      console.log(response);
       ProfileService.setProfileFromFacebook(response);
       $location.path('app/registration');
    });
  };
});
