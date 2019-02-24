(function () {
    'use strict';

    app.controller('LivroCtrl', ['$scope', '$injector', '$timeout', 'loadAnimeService', 'messageService',
        '$location', 'LivroService',
        function ($scope, $injector, $timeout, loadAnimeService, messageService, 
            $location, LivroService) {

            var vm = this;

            function startVm() {
               
                vm.bagLivro = [];               
                vm.user = {};
           
                vm.goCadastro = goCadastro;
                vm.goConsulta = goConsulta;
                vm.tela = 'Consulta';
                vm.file = [];

            };

            startVm();

            function getVm() {
                return vm;
            };


            vm.loadGrid = function () {
                loadAnimeService.show();
              
                LivroService.listAll(function (resp) {
                    if (resp !== null) {
                        vm.tela = 'Consulta';                        
                        vm.bagLivro = resp.data;
                        loadAnimeService.close();

                    }
                });



            };



            function goCadastro() {
                loadAnimeService.show();
                vm.tela = 'Cadastro';                       
                loadAnimeService.close();
            };

            function goConsulta() {
                vm.bagLivro = null;
                vm.bagLivro = [];
                loadAnimeService.show();
                vm.tela = 'Consulta';
                vm.loadGrid();
                loadAnimeService.close();
            };


            vm.goDeletar = function (codigo) {
                loadAnimeService.show();
                LivroService.delete(codigo, function (resp) {
                    if (resp !== null) {
                        vm.goConsulta();
                        messageService.success("Operação realizada com sucesso!");
                    }
                });
            };


            vm.goEditar = function (obj) {
                loadAnimeService.show();
                vm.tela = 'Cadastro';
                console.log(obj);
                vm = obj;
                loadAnimeService.close();
            };

            vm.goSaveOrUpdate = function () {
                loadAnimeService.show();
                LivroService.goSaveOrUpdate(vm, function (resp) {
                    if (resp !== null) {
                        vm.loadGrid();
                        messageService.success("Operação realizada com sucesso!");
                        loadAnimeService.close();
                    }
                });
                console.log(vm);
                loadAnimeService.close();
            };
            

            vm.mudaPreview = function (url) {
              
            };
            

            vm.loadGrid();


        }]);
})();