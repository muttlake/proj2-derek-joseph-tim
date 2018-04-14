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

    // stage ('TEST')
    // {
    //     dir ('PizzaStore/PizzaStore.Test/')
    //     {
    //         bat 'dotnet xunit -fxversion 2.0.6 -xml ../Tests/testresult.xml'
    //     }
    // }

    // stage ('ANALYZE')
    // {
    //     dir ('WeatherApp/')
    //     {
    //  		bat 'dotnet c:\\tools\\sonarqube\\sonarscanner.msbuild.dll begin /k:dd-key-2'
	// 	bat 'dotnet build'
	// 	bat 'dotnet c:\\tools\\sonarqube\\sonarscanner.msbuild.dll end'
    //     }
    // }


    stage ('PACKAGE')
    {

        dir ('WeatherApp/WeatherApp.DataSvc')
        {
            bat 'dotnet publish --output Publish'
        }

        dir ('WeatherApp/WeatherApp.LibSvc')
        {
            bat 'dotnet publish --output Publish'
        }

        dir ('WeatherApp/WeatherApp.ClientMVC')
        {
            bat 'dotnet publish --output Publish'
        }
    }

    stage ('DEPLOY')
    {

        dir ('WeatherApp/WeatherApp.DataSvc/')
        {
            bat 'msdeploy -verb:sync -source:iisApp="Publish" -dest:iisApp="Default Web Site/WeatherApp", -enableRule:AppOffline'
        }

        dir ('WeatherApp/WeatherApp.LibSvc/')
        {
            bat 'msdeploy -verb:sync -source:iisApp="Publish" -dest:iisApp="Default Web Site/WeatherApp", -enableRule:AppOffline'
        }

        dir ('WeatherApp/WeatherApp.ClientMVC/')
        {
            bat 'msdeploy -verb:sync -source:iisApp="Publish" -dest:iisApp="Default Web Site/WeatherApp", -enableRule:AppOffline'
        }


    }

}
