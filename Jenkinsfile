pipeline {
    agent any
    parameters {
        string(name: 'SOLUTION_PATH', defaultValue: 'WebAPISample.sln')
        string(name: 'TEST_PATH', defaultValue: 'WebAPITest/WebAPITest.csproj')
        choice(name: 'Environment', choices:['Build', 'Test','Both'])
    }
    stages {
        stage('Build') {
            when
            {
               expression
               {
                   params.Environment== 'Build' || params.Environment == 'Both'
               }
            }
            steps {
                sh 'dotnet restore ${SOLUTION_PATH} --source https://api.nuget.org/v3/index.json'
                sh 'dotnet build ${SOLUTION_PATH} -p:Configuration=release -v:n'
            }
        }
        stage('Test') {
             when
            {
               expression
               {
                   params.Environment== 'Test' || params.Environment == 'Both'
               }
            }
            steps {
                sh'dotnet test ${TEST_PATH}'
            }
        }
    }
}