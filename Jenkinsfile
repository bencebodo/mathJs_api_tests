pipeline {
    agent {
        docker { 
            image 'mcr.microsoft.com/dotnet/sdk:10.0' 
            args '-u root' 
        }
    }

    stages {
        stage('Checkout') {
            steps {
                echo 'Pull repository...'
                checkout scm
            }
        }

        stage('Restore & Build') {
            steps {
                echo 'Build solution...'
                sh 'dotnet restore'
                sh 'dotnet build --configuration Release'
            }
        }

        stage('API tests') {
            steps {
                catchError(buildResult: 'FAILURE', stageResult: 'FAILURE') {
                    sh 'dotnet test MathJS_Tests/math.js_tests.csproj --configuration Release'
                }
            }
        }
    }

    post {
    always {
        echo 'Pipeline finished!'
    }
}
}

def updateGitHubStatus(String contextName, String msg, String state) {
    step([
        $class: 'GitHubCommitStatusSetter',
        contextSource: [
            $class: 'ManuallyEnteredCommitContextSource',
            context: contextName
        ],
        statusResultSource: [
            $class: 'ConditionalStatusResultSource', 
            results: [
                [
                    $class: 'AnyBuildResult', 
                    message: msg, 
                    state: state
                ]
            ]
        ]
    ])
}