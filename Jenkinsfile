pipeline {
    agent any
    parameters {
        string(name: 'REPO_PATH', defaultValue: 'https://github.com/tavisca-rsingh/DemoWebAPI.git')
        string(name: 'SOLUTION_PATH', defaultValue: 'WebAPISample.sln')
        string(name: 'TEST_PATH', defaultValue: 'WebAPITest/WebAPITest.csproj')
    }
    stages {
        stage('Build') {
            steps {
                sh 'dotnet restore ${SOLUTION_PATH} --source https://api.nuget.org/v3/index.json'
                sh 'dotnet build ${SOLUTION_PATH} -p:Configuration=release -v:n'
            }
        }
        stage('Test') {
            steps {
                sh'dotnet test ${TEST_PATH}'
            }
        }
    }
}