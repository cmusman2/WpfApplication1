pipeline{
	agent any
 
	
	stages{
	
	       	stage('Example Print') {
                 	steps{
                        	echo "current build number: ${currentBuild.number}"
                      	}
               	}
	
    		stage('Compile')
       		{
         		steps{
                		echo "compiling ..."
              
         		}
        
       		}
 
       		stage('Build')
       		{
          		steps{
             			echo 'building...'
             			echo 'done'
           		}
       		}
       
       		stage('Test')
       		{
         		steps{
             			echo 'testing ...'         
             			echo 'done'
           		}
       		}
       
        	stage('ConfirmDeploy')
       		{
          		steps{
             			input('Ready to deploy?')
           		}
       		}
       		stage('Deploy')
       		{
         		steps{
                		echo 'deploying...'    
                		zip zipFile: "data_${currentBuild.number}.zip", archive: false, dir: "."
            		}
       		}
	}


}
