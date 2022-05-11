using UnityEngine;

public class SliceView : UnityView, IRotationListener, IEntityPositionListener, ISelectedListener
{
    [SerializeField]
    MeshRenderer meshRenderer;

    [SerializeField]
    GameObject selected;

    public override void Link(Contexts contexts, GameEntity e)
    {
        base.Link(contexts, e);
        e.AddRotationListener(this);
        e.AddEntityPositionListener(this);
        e.AddSelectedListener(this);

        Vector3 random = Random.insideUnitSphere;
        Color c = new Color(random.x, random.y, random.z, 1.0f);
        meshRenderer.material.color = c;

        OnSelected(e, false);
    }

    public void OnEntityPosition(GameEntity entity, Vector3 value)
    {
        transform.position = value;
    }

    public void OnRotation(GameEntity entity, Quaternion value)
    {
        transform.rotation = value;
    }

    public void OnSelected(GameEntity entity, bool value)
    {
        selected.SetActive(entity.selected.Value);
    }

    private void OnMouseUpAsButton()
    {
        LinkedEntity.isClicked = true;
    }
}
