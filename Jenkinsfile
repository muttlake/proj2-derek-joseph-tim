node
{
    stage ('IMPORT')
    {
        git url: 'https://github.com/1803-mar12-net/proj2-derek-joseph-tim.git', branch: 'master', credentialId: 'github-token'
    }

    stage ('BUILD')
    {

        dir ('WeatherApp/WeatherApp.DataSvc')
        {
            bat 'dotnet build'
        }

        dir ('WeatherApp/WeatherApp.LibSvc')
        {
            bat 'dotnet build'
        }

        dir ('WeatherApp/WeatherApp.ClientMVC')
        {
            bat 'dotnet build'
        }
    }

    stage ('TEST')
    {
        dir ('WeatherApp/WeatherApp.DataSvc/Weatherapp.DataTest/')
        {
            bat 'dotnet test'
        }

        dir ('WeatherApp/WeatherApp.LibSvc/Weatherapp.LibTest/')
        {
            bat 'dotnet test'
        }

        dir ('WeatherApp/WeatherApp.ClientMVC/Weatherapp.ClientTest/')
        {
            bat 'dotnet test'
        }
    }

    stage ('ANALYZE')
    {

        dir ('WeatherApp/WeatherApp.DataSvc')
        {
     		bat 'dotnet c:\\tools\\sonarqube\\sonarscanner.msbuild.dll begin /k:weatherapp_datasvc-key-80'
 		bat 'dotnet build'
 		bat 'dotnet c:\\tools\\sonarqube\\sonarscanner.msbuild.dll end'
        }

        dir ('WeatherApp/WeatherApp.LibSvc')
        {
     		bat 'dotnet c:\\tools\\sonarqube\\sonarscanner.msbuild.dll begin /k:weatherapp_libsvc-key-80'
 		bat 'dotnet build'
 		bat 'dotnet c:\\tools\\sonarqube\\sonarscanner.msbuild.dll end'
        }

        dir ('WeatherApp/WeatherApp.ClientMVC')
        {
     		bat 'dotnet c:\\tools\\sonarqube\\sonarscanner.msbuild.dll begin /k:weatherapp_clientmvc-key-80'
 		bat 'dotnet build'
 		bat 'dotnet c:\\tools\\sonarqube\\sonarscanner.msbuild.dll end'
        }

    }


    stage ('PACKAGE')
    {

        dir ('WeatherApp/WeatherApp.DataSvc')
        {
            bat 'dotnet publish --output ".\\bin"'
        }

        dir ('WeatherApp/WeatherApp.LibSvc')
        {
            bat 'dotnet publish --output ".\\bin"'
        }

        dir ('WeatherApp/WeatherApp.ClientMVC')
        {
            bat 'dotnet publish --output ".\\bin"'
        }
    }

    stage ('DEPLOY')
    {

        dir ('WeatherApp/WeatherApp.DataSvc/')
        {
            bat 'msdeploy -verb:sync -source:iisApp="C:\\Program Files (x86)\\Jenkins\\workspace\\devops-demo\\WeatherApp\\WeatherApp.DataSvc\\WeatherApp.DataSvc\\bin" -dest:iisApp="Default Web Site/DataSvc", -enableRule:AppOffline'
        }

        dir ('WeatherApp/WeatherApp.LibSvc/')
        {
            bat 'msdeploy -verb:sync -source:iisApp="C:\\Program Files (x86)\\Jenkins\\workspace\\devops-demo\\WeatherApp\\WeatherApp.LibSvc\\WeatherApp.LibSvc\\bin" -dest:iisApp="Default Web Site/LibSvc", -enableRule:AppOffline'
        }

        dir ('WeatherApp/WeatherApp.ClientMVC/')
        {
            bat 'msdeploy -verb:sync -source:iisApp="C:\\Program Files (x86)\\Jenkins\\workspace\\devops-demo\\WeatherApp\\WeatherApp.ClientMVC\\WeatherApp.ClientMVC\\bin" -dest:iisApp="Default Web Site/WeatherApp", -enableRule:AppOffline -skip:objectName=filePath,absolutePath="C:\\Program Files (x86)\\Jenkins\\workspace\\devops-demo\\WeatherApp\\WeatherApp.ClientMVC\\WeatherApp.ClientMVC\\wwwroot\\UserFiles\\Images\\.*"'
        }
    }

}
