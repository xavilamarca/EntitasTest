using UnityEngine;

public class SliceView : UnityView, IRotationListener, IEntityPositionListener
{
    [SerializeField]
    MeshRenderer meshRenderer;

    public override void Link(Contexts contexts, GameEntity e)
    {
        base.Link(contexts, e);
        e.AddRotationListener(this);
        e.AddEntityPositionListener(this);

        Vector3 random = Random.insideUnitSphere;
        Color c = new Color(random.x, random.y, random.z, 1.0f);
        meshRenderer.material.color = c;
    }

    public void OnEntityPosition(GameEntity entity, Vector3 value)
    {
        transform.position = value;
    }

    public void OnRotation(GameEntity entity, Quaternion value)
    {
        transform.rotation = value;
    }

    private void OnMouseUpAsButton()
    {
        LinkedEntity.isClicked = true;
    }
}
