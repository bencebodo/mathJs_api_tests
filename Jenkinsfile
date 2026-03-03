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
                script{
                    updateGitHubStatus('ci/jenkins/api-tests', 'API tests started...', 'PENDING')
                }

                catchError(buildResult: 'FAILURE', stageResult: 'FAILURE') {
                    sh 'dotnet test math.js_tests/math.js_tests.csproj --configuration Release'
                }

                script {
                    if (currentBuild.result == 'FAILURE') {
                        updateGitHubStatus('ci/jenkins/api-tests', 'API tests failed!', 'FAILURE')
                    } else {
                        updateGitHubStatus('ci/jenkins/api-tests', 'API tests passed!', 'SUCCESS')
                    }
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