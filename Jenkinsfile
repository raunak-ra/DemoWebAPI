pipeline {
    agent any
    parameters {
		
		string(name: 'SOLUTION_FILE_PATH', defaultValue: 'WebAPISample.sln')
		string(name: 'SOLUTION_TEST_PATH', defaultValue: 'WebAPITest/WebAPITest.csproj')
		string(name: 'PROJECT_NAME', defaultValue: 'DemoWebAPI')
		string(name: 'PORT_NO', defaultValue: '4555')
                string(name: 'DOCKERHUB_USERNAME', defaultValue: 'raunakrs')
                string(name: 'DOCKERHUB_PASSWORD')
                string(name: 'DOCKER_REPO_NAME', defaultValue: 'samplewebapi')
                string(name: 'SONAR_SCANNER_MSBUILD_PATH', defaultValue: ' C:\Users\rsingh\Desktop\sonar-scanner-msbuild-4.6.2.2108-netcoreapp2.0\SonarScanner.MSBuild.dll')
                string(name: 'SONARQUBE_PROJECT', defaultValue: 'web_api')
                string(name: 'SONARQUBE_TOKEN', defaultValue: '8c01a0ab64ff1e67621cdffcc852376391dbee78')
                choice(name: 'Environment', choices:['Build', 'Deploy'])

            }
 
    stages {
        stage('Build') {
        	 when
            {
               expression
               {
                   params.Environment == 'Build' || params.Environment == 'Deploy'
               }
            }
            steps {

                bat '''  
                                 echo "----------------------------Sonar Scanner Started-----------------------------"
                                 dotnet sonarscanner begin /k:"%SONARQUBE_PROJECT%" /d:sonar.login="%SONAR_QUBE_TOKEN%"            
               
				echo "----------------------------Build Started-----------------------------"
				dotnet build %SOLUTION_FILE_PATH% -p:Configuration=release -v:n
				echo "----------------------------Build Completed-----------------------------"

				
				echo "----------------------------Test Started-----------------------------"
				dotnet test %SOLUTION_TEST_PATH%
				echo "----------------------------Test Completed-----------------------------"

                                dotnet %SONAR_SCANNER_MSBUILD_PATH% end /d:sonar.login="%SONARQUBE_TOKEN%"                
				echo "----------------------------Sonar Scanner Completed----------------------------"

				
				echo "----------------------------Publish Started-----------------------------"
				dotnet publish %SOLUTION_FILE_PATH% -c Release -o ../publish
				echo "----------------------------Publish Completed-----------------------------"

				
				echo "----------------------------Docker Image Started-----------------------------"
				docker build --tag=%DOCKERHUB_USERNAME%/%DOCKER_REPO_NAME% --build-arg project_name=%PROJECT_NAME%.dll .
				echo "----------------------------Docker Image Completed-----------------------------"

				'''
			    }
			}
				
        stage('Deploy') {
        	 when
            {
               expression
               {
                   params.Environment == 'Deploy'
               }
            }
            
            steps {
                bat '''
				echo "----------------------------Push Started-----------------------------"
				docker login -u %DOCKERHUB_USERNAME% -p %DOCKERHUB_PASSWORD%
                                
				docker push %DOCKERHUB_USERNAME%/%DOCKER_REPO_NAME%:latest
				echo "----------------------------Push Completed-----------------------------"
				
				'''
            }
        }
    }
}