starterControllers.controller('RegistrationCtrl', function ($scope, $stateParams, Facebook, LocalStorage) {
  $scope.fbMe = function () {
    // From now on you can use the Facebook service just as Facebook api says
    Facebook.api('/me', function (response) {
      $scope.user = response;
      console.log($scope.user);
    });
  };

  $scope.doRegister = function (valid) {
    $scope.submitted = true;

    if (!$scope.loginData.password) {
      valid = false;
    } else if ($scope.loginData.password.length < 7) {
      valid = false;
    } else {
      $scope.passwordError = null;
    }

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
