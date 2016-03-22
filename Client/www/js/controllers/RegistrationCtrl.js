starterControllers.controller('RegistrationCtrl', function ($scope, $stateParams, ProfileService) {
  ProfileService.getFaceBookProfile().then(function (profile) {
    $scope.user = profile;
  });
  /*
   *  DoB
   *  Email
   *  Profile Picture
   */
  $scope.doRegister = function (valid) {
    $scope.submitted = true;



    $scope.updatePasswordError();

    if (valid) {
      LoadingSvc.show();
      Users.signup({}, $scope.loginData
        , function (user) {
          LocalStorage.user = user;
          $scope.authentication.user = user;
          $location.path('valuations');
          LoadingSvc.hide();
        }
        , function (errorResponse) {
          console.log('error signing user up');
          $scope.error = errorResponse.data.message;
          LoadingSvc.hide();
        });
    } else {
      $scope.error = 'Please fill in all required fields';
    }
  }
});
