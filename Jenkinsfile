pipeline {
    agent any
    parameters {
        string(name: 'SOLUTION_PATH', defaultValue: 'WebAPISample.sln')
        string(name: 'TEST_PATH', defaultValue: 'WebAPITest/WebAPITest.csproj')
        choice(name: 'Environment', choices:['Build', 'Test','Publish','Deploy','All'])
    }
    stages {
        stage('Build') {
            when
            {
               expression
               {
                   params.Environment== 'Build' || params.Environment == 'All'
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
                   params.Environment== 'Test'
               }
            }
            steps {
                sh'dotnet test ${TEST_PATH}'
            }
        }
        stage('Publish') {
             when
            {
               expression
               {
                   params.Environment== 'Publish' || params.Environment == 'All'
               }
            }
            steps {
                sh'dotnet publish ${SOLUTION_PATH}'
            }
        }
         stage('Deploy') {
             when
            {
               expression
               {
                   params.Environment== 'Deploy' || params.Environment == 'All'
               }
            }
            steps {
                sh'dotnet WebAPISample/bin/Release/netcoreapp2.2/WebAPISample.dll'
            }
        }
    }
}
