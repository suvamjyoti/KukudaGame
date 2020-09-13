using UnityEngine;
using UnityEngine.SceneManagement;

public class kukuda : MonoBehaviour
{
    [SerializeField] private float BirdForce = 10f;
    private Vector3 _initialPosition;
    
    
    private bool _birdLaunched;
    private bool _birdOutBound;
    
    private float _timeSittingAround;
    
    
    private void Awake() {
        _initialPosition = transform.position;

    }

    private void Update() {
        
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);

        if(_birdLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1){
            _timeSittingAround += Time.deltaTime;
        }

        if(transform.position.x > 12 || transform.position.y > 6 
        || transform.position.x < -15 || transform.position.y < -6
        || _timeSittingAround >2 || _birdOutBound){
            string CurrentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(CurrentSceneName);
        }
    }

    private void OnMouseDown(){
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnMouseDrag(){

         if(transform.position.x < 0 && transform.position.y < 6 
        && transform.position.x > -10 && transform.position.y > -6){
            _birdOutBound = false;
             Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(newPosition.x,newPosition.y) ;
            GetComponent<LineRenderer>().enabled = true;

        }
        else{
            _birdOutBound = true;
        }
        
           
    }

    private void OnMouseUp(){
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directionToInitialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition*BirdForce);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdLaunched = true;
        GetComponent<LineRenderer>().enabled = false;
    }

}
